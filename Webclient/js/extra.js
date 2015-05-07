var nummer;
var string;

$("#form").children().change(function () {
    if (nummer == 1 && string == 1) {
        $("#startgame").prop('disabled', false);
    }
    else
    {
        $("#startgame").prop('disabled', true);
    }
});


$(".numeric").each(function () {
    if (!isNaN($(this).val()) && $(this).val() != "")
    {
        console.log("nummer");
        nummer == 1;

    }
    else {
        console.log("geen nummer");
        nummer == 0;
    }
});

$(".string").each(function () {
    if (isNaN($(this).val()) && $(this).val() != "") {
        console.log("string");
       string == 1;

    }
    else {
        console.log("geen string");
        string == 0;
    }
});


