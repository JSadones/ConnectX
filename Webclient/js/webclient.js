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

        function getSecondClass(thisObj) {
            var counter = 0;
            var classes = {};
            $(thisObj.attr('class').split(' ')).each(function() { 
                if (this !== '') {
                    classes[counter] = this;
                }    
                counter++;
            });
            return classes[1];
        }

        function insertToken(column) {
            ajaxCall(callback, "insertToken", column, playerAtPlay);
        }

        function insertTokenByAI() {
            var column = ~~(Math.random() * columns);
            insertToken(column);
        }

       $(document).on("mouseenter", ".column", function() {
           $('.' + getSecondClass($(this)).toString()).css("background-color", "red");
        });

        $(document).on("mouseleave", ".column", function() {
            $('.'+getSecondClass($(this)).toString()).css("background-color","transparent");
        });

        $(document).on("click", ".column", function() {
            var column = getSecondClass($(this)).replace(/\D/g,'');
            
            console.log("click");
            insertToken(column); 
        });

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
            $( "#raster" ).hide();
        }

        function initializeRaster() {
            for (var i=0; i<columns; i++) {
                for (var j=0; j<rows;j++) {
                    $('.row'+j+'.column'+i).html("-");

                }
            }
        }

        function callback(data) {
            if (data[0].type=="insertToken") {
                if(data[0].status == "True") {
                    $('.row'+data[0].row+'.column'+data[0].column).html(data[0].player);


                    if (data[0].won == "True")
                    {
                        alert("Game won by player " + data[0].player);
                        scores[data[0].player]++;
                        $('#player'+data[0].player).html(scores[data[0].player]);
                        if(confirm("Play another game?")) {
                            ajaxCall(callback, "nextGame");
                        } else endGame();
                    } else if (data[0].full == "True")
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

                } else {
                    if (!multiplayer && playerAtPlay == 2) insertTokenByAI();
                    else alert('column full');
                }
            
            } else if (data[0].type=="nextGame") {
                if(data[0].status == "True") {
                    initializeRaster();
                    playerAtPlay = 1;

                } 
            
            } 
        }

        function ajaxCall(callback) {

            $.support.cors = true;
            $.ajax({
                type: "POST",
                crossdomain: true,
                contentType: "application/json; charset=utf-8",
                url: "http://127.0.0.1:8000/",
                dataType: "jsonp",
                data: { action : arguments[1], Param2 : arguments[2], Param3: arguments[3], Param4: arguments[4]},
                success: function (data) {
                  callback(data);
                }
            });

        }

        $('#form').submit(function () {


            var $inputs = $('#form :input');

            var values = {};
            $inputs.each(function() {
                values[this.name] = $(this).val();
            });

            var content = "<table width='70%'><tr id='selectie'>";

            columns = values["columns"];
            rows = values["rows"];

            for (var i = 0; i < values["columns"]; i++) {
                content += "<th>o</th>";
            }
                
            content += '</tr>';
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
            $("#nameplayer2").html(values["nameplayer2"]);

            $( "#raster" ).html(content);

            $('#options').hide();
            $( "#stats" ).show();

            $( "#raster" ).show();



            return false;
        

        });
    });

})();