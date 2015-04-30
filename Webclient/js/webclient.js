$(document).ready(function(){   
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
        var player = 1;
        ajaxCall(callback, "insertToken", column, player);
    }

   $(document).on("mouseenter", ".column", function() {
       $('.' + getSecondClass($(this)).toString()).css("background-color", "red");
    });

    $(document).on("mouseleave", ".column", function() {
        $('.'+getSecondClass($(this)).toString()).css("background-color","transparent");
    });

    $(document).on("click", ".column", function() {
        var column = getSecondClass($(this)).replace(/\D/g,'');
        
        if(insertTokenAndGetRow(column)) {
            $('.row.b')
        } else {

        }
        
    });

    function callback(data, request, param1) {
        console.log(data);
        console.log(request);
        console.log(param1);

    }

    function ajaxCall(callback, request, param1) {

        $.support.cors = true;
        $.ajax({
            type: "POST",
            crossdomain: true,
            contentType: "application/json; charset=utf-8",
            url: "http://127.0.0.1:8000/",
            dataType: "jsonp",
            data: { Param1 : arguments[1], Param2 : arguments[2], Param3: arguments[3]},
            success: function (data) {
              callback(data, request, param1);
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

        for (var i = 0; i < values["columns"]; i++) {
            content += "<th>o</th>";
        }
            
        content += '</tr>';
        for (var i = 0; i< values["rows"]; i++) {
            content += '<tr>';
            for (var j = 0; j < values["columns"]; j++) {
                content += "<td class='column column"+j+" row"+i+"'>x</td>"
            }
            content += '</tr>';
        }
        content += '</table>';

        ajaxCall(callback, "startGame");

        $( "#raster" ).html(content);

        $('#options').hide();

        $( "#raster" ).show();



        return false;
    

    });
});

