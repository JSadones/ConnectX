$("input").change(function veldenCheck() {


});

$(".numeric").change(function nummerCheck() {
    if (!isNaN($(this).val()) && $(this).val() != "") {
        $("#startgame").prop('disabled', false);
        console.log("true");

        $(".numeric").each(function nummerCheck() {

            if (isNaN($(this).val()) || $(this).val() == "") {
                $("#startgame").prop('disabled', true);
                console.log("false");
            }
        });

    }
    else {
        $("#startgame").prop('disabled', true);
        console.log("false");
    }
});


$(".string").change(function playerCheck() {
    if (isNaN($(this).val()) && $(this).val() != "") {
        $("#startgame").prop('disabled', false);
        console.log("true");

        $(".string").each(function playerCheck() {

            if (!isNaN($(this).val()) || $(this).val() == "") {
                $("#startgame").prop('disabled', true);
                console.log("false");
            }
        });

    }
    else {
        $("#startgame").prop('disabled', true);
        console.log("false");
    }
});