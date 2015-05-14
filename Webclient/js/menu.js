$(document).ready(function () {
    $( "#play-vs-cpu" ).click(function() {
        window.multiplayer = false;
        showForm(false);
    });
    
    $( "#play-multiplayer" ).click(function() {
        window.multiplayer = true;
        showForm(true);
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

    $('#form').submit(function () {

        values = processFormInputs();

        rows = values["rows"];
        columns = values["columns"];

        window.connectx.newSession();

        var table = createTable(rows, columns);

        ajaxCall(callback, "startGame", values["rows"], values["columns"], values["streak"]);

        setNames(values["nameplayer1"],values["nameplayer2"]);
        
        $( "#rasterwrapper" ).html(table);


        window.game.show();
        hide();

        return false;

    });

    

    function processFormInputs() {

        $('#form :input').each(function() {
            values[this.name] = $(this).val();
        });

        return values;

    }
});