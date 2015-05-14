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
        var difficulty =  $("input:radio[name ='difficulty']:checked").val();
        console.log(difficulty);


        window.game.start(rows, columns, streak, difficulty, namePlayer1, namePlayer2);
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