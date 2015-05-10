$(document).ready(function () {

    var numeric;
    var minimum = 4;
    var minimumCheck;
    var string;

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
                minimumCheck = true;

            }
            else {
                console.log("te klein");
                minimumCheck = false;
            }
        });

        $(".string").each(function () {
            if (isNaN($(this).val()) && $(this).val() != "") {
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

        if (numeric == true && string == true && minimumCheck == true) {
            $("#startgame").prop('disabled', false);
            console.log("check klopt");
        }
        else {
            $("#startgame").prop('disabled', true);
            console.log("check klopt niet");
        }
    });


});