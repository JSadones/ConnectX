$(document).ready(function () {

    var numeric;
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

        if (numeric == true && string == true) {
            $("#startgame").prop('disabled', false);
            console.log("check klopt");
        }
        else {
            $("#startgame").prop('disabled', true);
            console.log("check klopt niet");
        }
    });


});