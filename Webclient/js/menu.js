$(document).ready(function () {
    $( "#play-vs-cpu" ).click(function() {
        window.multiplayer = false;
        showForm(false);
    });
    
    $( "#play-multiplayer" ).click(function() {
        window.multiplayer = true;
        showForm(true);
    });



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




    function showForm(multiplayer) {
        if (multiplayer) 
            $( ".multiplayer-option" ).show();
        else  {
            $( ".multiplayer-option" ).hide();
            $("#form input[name=nameplayer2]").val('CPU');
        }
        hide();
        $( "#options" ).show();
    }
    window.menu = {};
    menu.show = function () {   
        $('#start').show();        
    }
    function hide () {   
        $('#start').hide();        
    }

    function hideForm () {   
        $('#options').hide();        
    }



    $('#form').submit(function () {

        values = processFormInputs();

        var rows = values["rows"];
        var columns = values["columns"];
        var streak = values["streak"];
        var namePlayer1 = values["nameplayer1"];
        var namePlayer2 = values["nameplayer2"];

        window.connectx.newSession();

        window.game.start(rows, columns, streak, namePlayer1, namePlayer2);

        hideForm();

        return false;

    });

    

    function processFormInputs() {

        var values = {};

        $('#form :input').each(function() {
            values[this.name] = $(this).val();
        });

        return values;

    }
});