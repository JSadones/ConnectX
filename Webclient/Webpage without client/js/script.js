// JavaScript source code

$(document).ready(function () {
    $('div.container-nav').mouseenter(function () {
        $(this).animate({
            height: '+=10px'
        });
        $('h1').addClass(".bigger");
    });
    $('div.container-nav').mouseleave(function () {
        $(this).animate({
            height: '-=10px'
        });
        $('h1').removeClass(".bigger");
    });
    $('div.container-footer').mouseenter(function () {
        $(this).animate({
            height: '+=10px'
        });
    });
    $('div.container-footer').mouseleave(function () {
        $(this).animate({
            height: '-=10px'
        });
    });
});
