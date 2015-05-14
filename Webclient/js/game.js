$(document).ready(function () {

    var numeric;
    var minimum = 4;
    var minStreak = 4;
    var defRows = 6;
    var defColumns = 7;
    var faultCheck;
    var minCheck;
    var string;



    function correctFaults() {

        var rowCheck;
        var columnCheck;
        var streakCheck;



        $("#rows").each(function () {
            if ($(this).val() >= defRows)
            {
                rowCheck = true;
                console.log('rowCheck OK');
            }
            else {
                rowCheck = false;
                console.log('rowCheck Niet OK');
            }
        });
            
            
        $("#columns").each(function () {
            if ($(this).val() >= defColumns)
                {
                columnCheck = true;
                console.log('columnCheck OK');
                }
            else
                {
                columnCheck = false;
                console.log('columnCheck Niet OK')
                }
        });


        $("#streak").each(function () {

            if ($(this).val() >= minStreak) {
                streakCheck = true;
                console.log('streakCheck OK');
            }
            else {
                streakCheck = false;
                console.log('streakCheck Niet OK');
            }
        });

        if (rowCheck == true && columnCheck == true && streakCheck == true) {
            return faultCheck = true;
        }
        else {
            $("#rows").val('6');
            $("#columns").val('7');
            $("#streak").val('4');
            console.log('velden gecorrigeerd');
        }


    }


    function checkInputs() {


        $(".numeric").each(function () {
            if (!isNaN($(this).val()) && $(this).val() != "") {
                console.log("nummer");
                numeric = true;

            }
            else {
                console.log("geen nummer");
                numeric = false;
            }
        });

        $(".minimum").each(function () {
            if ($(this).val() >= minimum) {
                console.log("minimum voldaan");
                minCheck = true;

            }
            else {
                console.log("te klein");
                minCheck = false;
            }
        });

        $(".string").each(function () {
            if ($(this).val() != "") {
                console.log("string");
                string = true;

            }
            else {
                console.log("geen string");
                string = false;
            }
        });
    }

    $("#form").children().change(function () {

        checkInputs();
        correctFaults();

        if (numeric == true && string == true && minCheck == true && faultCheck == true) {
            $("#startgame").prop('disabled', false);
            console.log("check klopt");
        }
        else {
            $("#startgame").prop('disabled', true);
            console.log("check klopt niet");
        }
    });

     $(".token1").each(function () {
 
        var ctx = $('.token1')[0].getContext("2d");
 
        //draw a circle
        ctx.fillStyle = "#427EC1"
        ctx.beginPath();
        ctx.arc(75, 75, 10, 0, Math.PI * 2, true);
        ctx.closePath();
        ctx.fill();
 
    });
 
    $(".token2").each(function () {
 
        var ctx = $('.token2')[0].getContext("2d");
 
        //draw a circle
        ctx.fillStyle = "#EF4136"
        ctx.beginPath();
        ctx.arc(75, 75, 10, 0, Math.PI * 2, true);
        ctx.closePath();
        ctx.fill();
 
    });

     $('#form').submit(function () {

        values = processFormInputs();

        rows = values["rows"];
        columns = values["columns"];

        window.game.newSession();

        var table = createTable(rows, columns);

        ajaxCall(callback, "startGame", values["rows"], values["columns"], values["streak"]);

        setNames(values["nameplayer1"],values["nameplayer2"]);
        
        $( "#rasterwrapper" ).html(table);


        window.game.show();
        hide();

        return false;

    });

    function hide() {
        $('#options').hide();
    }

    function processFormInputs() {

        $('#form :input').each(function() {
            values[this.name] = $(this).val();
        });

        if (!multiplayer) values["nameplayer2"] = "CPU";
    }



});