$(document).ready(function(){   

    var playerAtPlay = 1;
    var rows = 0;
    var columns = 0;
        // Start
            // Show start div
        // Options
            // Show options div
    $( "#play-vs-cpu" ).click(function() {
        $('#start').hide();
        $( "#options" ).show();
        $( ".multiplayer-option" ).hide();

    });
    $( "#play-multiplayer" ).click(function() {
        $('#start').hide();
        $( "#options" ).show();
        $( ".multiplayer-option" ).show();

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
        if (playerAtPlay == 1) playerAtPlay = 2;
        else playerAtPlay = 1;
    }


   $(document).on("mouseenter", ".column", function() {
       $('.' + getSecondClass($(this)).toString()).css("background-color", "red");
    });

    $(document).on("mouseleave", ".column", function() {
        $('.'+getSecondClass($(this)).toString()).css("background-color","transparent");
    });

    $(document).on("click", ".column", function() {
        var column = getSecondClass($(this)).replace(/\D/g,'');
        

        insertToken(column); 
        
    });

    function nextGame() {
        initializeRaster();
    }

    function endGame() {
        $('#start').show();
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
        console.log(data);
        if (data[0].type=="insertToken") {
            if(data[0].status == "True") {
                $('.row'+data[0].row+'.column'+data[0].column).html(data[0].player);


                if (data[0].won == "True")
                {
                    alert("Game won by player " + data[0].player);
                    if(confirm("Play another game?")) {
                        ajaxCall(callback, "nextGame");
                    } else endGame();
                }
            } else {
                alert('no');
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
            data: { Param1 : arguments[1], Param2 : arguments[2], Param3: arguments[3]},
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

        ajaxCall(callback, "startGame", values["rows"], values["columns"]);

        $( "#raster" ).html(content);

        $('#options').hide();

        $( "#raster" ).show();



        return false;
    

    });
});

