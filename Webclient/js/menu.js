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
        $( "#options" ).show();
    }
    window.menu = {};
    menu.show = function () {   
        $('#start').show();        
    }
});