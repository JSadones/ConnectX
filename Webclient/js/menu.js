$(document).ready(function () {
    $( "#play-vs-cpu" ).click(function() {
        window.multiplayer = false;
        showForm(false);
    });
    
    $( "#play-multiplayer" ).click(function() {
        window.multiplayer = true;
        showForm(true);
    });
    
    $( "#form :input" ).change(function() {
        console.log('here');
        var streak = parseInt($("#form input[name=streak]").val());
        var rows = parseInt($("#form input[name=rows]").val());
        var columns = parseInt($("#form input[name=columns]").val());

        console.log(streak + '-' + rows + '-' + columns)
        if (streak > rows && streak > columns) {
            $("#form input[name=streak]").val(Math.max(rows, columns));
            console.log('max');
        }
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
        if (multiplayer) {
            $( ".multiplayer-option" ).css('display','inline-block'); 
            $( ".ai-option" ).hide();     
            $("#form input[name=nameplayer2]").html('');
        }
        else  {
            $( ".multiplayer-option" ).hide();

            $( ".ai-option" ).css('display','inline-block');  
            $("#form input[name=nameplayer2]").val('CPU');
        }
        hide();
        $( "#options" ).css('display','inline-block');  
    }
    window.menu = {};
    menu.show = function () {   
        $('#start').css('display','inline-block');  
    }
    function hide () {   
        $('#start').css('display','none');  
    }

    function hideForm () {   
        $('#options').css('display','none');  
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