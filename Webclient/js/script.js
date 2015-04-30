// JavaScript source code

$(document).ready(function () {
    $('div.container-nav').mouseenter(function () {
        $(this).animate({
            height: '+=10px'
        });
    });
    $('div.container-nav').mouseleave(function () {
        $(this).animate({
            height: '-=10px'
        });
    });
    $('div.container-footer').mouseenter(function () {
        $(this).animate({
            height: '+=10px'
        });
		$(div.wrapper).animate({
			height: '+=10%'
		});
    });
    $('div.container-footer').mouseleave(function () {
        $(this).animate({
            height: '-=10px'
        });
		$(div.wrapper).animate({
			height: '-=10%'
		});
    });
});
