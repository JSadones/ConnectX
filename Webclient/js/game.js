$(document).ready(function () {

    var playerAtPlay = 1;
    var scores = [];
    var rows = 0;
    var columns = 0;
    var streak = 4;
    var ajaxrequest = false;
   

    $(document).on("mouseenter", "#raster td", function() {
       $('.' + getClassnameOfIndexedColumn($(this)).toString()).css("background-color", "dimgray");
    });

    $(document).on("mouseleave", "#raster td", function() {
        $('.'+getClassnameOfIndexedColumn($(this)).toString()).css("background-color","transparent");
    });

    $(document).on("click", "#raster td", function() {
        var column = getClassnameOfIndexedColumn($(this)).replace(/\D/g,'');
        
        if (ajaxrequest == false) {insertToken(column); console.log("start false");}
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
        ajaxCall(callback, "insertTokenByAI");
    }

    function nextGame() {
        initializeRaster();
    }

    function endGame() {
        showWinner();
        initializeRaster();
        resetScores();
        showMenu();
    }

    function showWinner() {
        if (scores[1] == scores[2])
            alert("It's a tie!");
        else if (scores[1] > scores[2])
            alert("Player 1 won the session");
        else alert("Player 2 won the session");            
    }

    function showMenu() {
        hide();
        window.menu.show();
    }

    function resetScores() {
        $("#player1").html("0");
        $("#player2").html("0");
    }

    function initializeRaster() {
        for (var i=0; i<columns; i++) {
            for (var j=0; j<rows;j++) {
                $('.row'+j+'.column'+i).removeClass( "token1" );
                $('.row'+j+'.column'+i).removeClass( "token2" );
            }
        }
    }

    function callback(data) {
        console.log(data);
        if (data.request.action =="insertToken" || data.request.action =="insertTokenByAI") {

            if(data.status == true) {

                processInsertedToken(data.response);
             
            } else if (!multiplayer && playerAtPlay == 2) {
                insertTokenByAI();
            } else alert('column full');
            
        } else if (data.request.action =="nextGame") {
            if(data.status == true) {
                initializeRaster();
                playerAtPlay = 1;
                $('#container-sidebar-right p').removeClass('active');
                $('#container-sidebar-left p').addClass('active');

            } 
        
        } else if (data.request.action == 'startGame') {
            
            if (data.status == true) show();
            else showMenu();
        }
        ajaxrequest = false;
        console.log("end false");
    }

    function processInsertedToken(response) {
        $('.row'+response.row+'.column'+response.column).addClass('token'+response.player);
        checkIfGameIsWon(response);
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
            
            if (playerAtPlay == 1){ playerAtPlay = 2;
                $('#container-sidebar-left p').removeClass('active');
                $('#container-sidebar-right p').addClass('active');
            }
            else{ 
                playerAtPlay = 1;
                $('#container-sidebar-right p').removeClass('active');
                $('#container-sidebar-left p').addClass('active');
            }

            if (!multiplayer && playerAtPlay == 2 ) {
                insertTokenByAI();
            }
        }

    }

    function ajaxCall(callback) {
        ajaxrequest = true;

        var d = {action:arguments[1]}

        switch (d.action) {
            case "startGame" : 
                d.rows = arguments[2];
                d.columns = arguments[3];
                d.streak = arguments[4];
                d.difficulty = arguments[5];
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

    function createTable(rows, columns) {
        var content = "<table width='70%' id='raster'>";
            
        for (var i = rows - 1; i >= 0; i--) {
            content += '<tr>';
            for (var j = 0; j < columns; j++) {
                content += "<td class='column"+j+" row"+i+"'><div id='tokenframe'></div></td>"
            }
            content += '</tr>';
        }
        content += '</table>';


        return content;
    }

    function setNames(player1, player2) {
        $("#nameplayer1").html(player1);
        $("#nameplayer2").html(player2);
    }

    function show() {
        $( "#container-sidebar-left" ).css('display','inline-block'); 
        $( "#container-sidebar-right" ).css('display','inline-block');   
        $( "#raster" ).show();  
    }

    function hide() {
        $( "#container-sidebar-left" ).css('display','none');  
        $( "#container-sidebar-right" ).css('display','none');  
        $( "#raster" ).hide();   

    }

    start = function (r, c, s, d, namePlayer1, namePlayer2) {
        
        rows = r;
        columns = c;

        var table = createTable(rows, columns);

        scores[1] = 0;
        scores[2] = 0; 
        setNames(namePlayer1, namePlayer2);
        ajaxCall(callback, "startGame", rows, columns, streak, d);
        
        $( "#rasterwrapper" ).html(table);
        show();

    }

    window.game.start = start;
    window.connectx = {};
    window.connectx.newSession = function () {
    }

});