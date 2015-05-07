(function(){

    $(document).ready(function(){   

        var playerAtPlay = 1;
        var scores = [];
        var rows = 0;
        var columns = 0;
        var streak = 4;
        var multiplayer = false;


        scores[1] = 0;
        scores[2] = 0; 

        // Click Handlers

        $( "#play-vs-cpu" ).click(function() {
            $('#start').hide();
            $( "#options" ).show();
            $( "#stats" ).hide();
            $( ".multiplayer-option" ).hide();
            multiplayer = false;

        });
        $( "#play-multiplayer" ).click(function() {
            $('#start').hide();
            $( "#options" ).show();
            $( "#stats" ).hide();
            $( ".multiplayer-option" ).show();
            multiplayer = true;
        });

        $(document).on("mouseenter", ".column", function() {
           $('.' + getClassnameOfIndexedColumn($(this)).toString()).css("background-color", "red");
        });

        $(document).on("mouseleave", ".column", function() {
            $('.'+getClassnameOfIndexedColumn($(this)).toString()).css("background-color","transparent");
        });

        $(document).on("click", ".column", function() {
            var column = getClassnameOfIndexedColumn($(this)).replace(/\D/g,'');
            
            insertToken(column); 
        });

        function getClassnameOfIndexedColumn(thisObj) {
            var classname = "";
            $(thisObj.attr('class').split(' ')).each(function() { 
                str = this.replace('column', '');
                if (!isNaN(str)) {
                    classname = this;
                }    
            });
            return classname;
        }

        function insertToken(column) {
            ajaxCall(callback, "insertToken", column, playerAtPlay);
        }

        function insertTokenByAI() {
            var column = ~~(Math.random() * columns);
            insertToken(column);
        }

        function nextGame() {
            initializeRaster();
        }

        function endGame() {

            if (scores[1] == scores[2])
                alert("It's a tie!");
            else if (scores[1] > scores[2])
                alert("Player 1 won the session");
            else alert("Player 2 won the session");

            initializeRaster();
            $("#player1").html("0");
            $("#player2").html("0");
            $('#start').show();
            $( "#stats" ).hide();
            $( "#options" ).hide();
            $( "#rasterwrapper" ).hide();
        }

        function initializeRaster() {
            for (var i=0; i<columns; i++) {
                for (var j=0; j<rows;j++) {
                    $('.row'+j+'.column'+i).html("-");

                }
            }
        }

        function callback(data) {
            console.log(data);
            if (data.request.action =="insertToken") {

                if(data.status == true) {

                    processInsertedToken(data.response);
            checkIfGameIsWon(data.response);
                    

                } else {
                    if (!multiplayer && playerAtPlay == 2) insertTokenByAI();
                    else alert('column full');
                }
            
            } else if (data.request.action =="nextGame") {
                if(data.status == true) {
                    initializeRaster();
                    playerAtPlay = 1;

                } 
            
            } 
        }

        function processInsertedToken(response) {

            $('.row'+response.row+'.column'+response.column).html(response.player);


            
        }

        function checkIfGameIsWon(response) {
            if (response.won == "True")
            {
                alert("Game won by player " + response.player);
                scores[response.player]++;
                $('#player'+response.player).html(scores[response.player]);
                if(confirm("Play another game?")) {
                    ajaxCall(callback, "nextGame");
                } else endGame();

            } else if (response.full == "True")
            {
                alert("Raster full");
                if(confirm("Play another game?")) {
                    ajaxCall(callback, "nextGame");
                } else endGame();

            } else{
                

                if (playerAtPlay == 1) playerAtPlay = 2;
                else playerAtPlay = 1;

                if (!multiplayer && playerAtPlay == 2 ) {
                    insertTokenByAI();
                }
            }
        }

        function ajaxCall(callback) {

            var d = {action:arguments[1]}

            switch (d.action) {
                case "startGame" : 
                    d.rows = arguments[2];
                    d.columns = arguments[3];
                    d.streak = arguments[4];
                    break;
                case "insertToken":
                    d.column = arguments[2];
                    d.player = arguments[3];

                    break;
            }
            console.log(d);

            $.support.cors = true;
            $.ajax({
                type: "POST",
                crossdomain: true,
                contentType: "application/json; charset=utf-8",
                url: "http://127.0.0.1:8000/",
                dataType: "jsonp",
                data: d,
                success: function (data) {
                  callback(data);
                }
            });

        }

        //

        $('#form').submit(function () {


            var $inputs = $('#form :input');

            var values = {};
            $inputs.each(function() {
                values[this.name] = $(this).val();
            });

            var content = "<table width='70%' id='raster'>";

            columns = values["columns"];
            rows = values["rows"];
                
            for (var i = values["rows"] - 1; i >= 0; i--) {
                content += '<tr>';
                for (var j = 0; j < values["columns"]; j++) {
                    content += "<td class='column column"+j+" row"+i+"'>_</td>"
                }
                content += '</tr>';
            }
            content += '</table>';

            ajaxCall(callback, "startGame", values["rows"], values["columns"], values["streak"]);

            $("#nameplayer1").html(values["nameplayer1"]);

            if (multiplayer == true) $("#nameplayer2").html(values["nameplayer2"]);
            else $("#nameplayer2").html("CPU");

            $( "#rasterwrapper" ).html(content);

            $('#options').hide();
            $( "#stats" ).show();

            $( "#rasterwrapper" ).show();

            return false;

        });
    });

})();