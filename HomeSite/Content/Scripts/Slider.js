var slideWidth = 649;
var sliderTimer;
$(function () {
    $('.slidewrapper').width($('.slidewrapper').children().length * slideWidth);
    sliderTimer = setInterval(nextSlide, 3000);
    $('.slider_img').hover(function () {
        clearInterval(sliderTimer);
    }, function () {
        sliderTimer = setInterval(nextSlide, 3000);
    });
    $('#next_slide').click(function () {
        clearInterval(sliderTimer);
        nextSlide();
        sliderTimer = setInterval(nextSlide, 3000);
    });
    $('#prev_slide').click(function () {
        clearInterval(sliderTimer);
        prevSlide();
        sliderTimer = setInterval(nextSlide, 3000);
    });
});

function nextSlide() {
    var currentSlide = parseInt($('.slidewrapper').data('current'));
    currentSlide++;
    if (currentSlide >= $('.slidewrapper').children().length) {
        currentSlide = 0;
    }
    $('.slidewrapper').animate({ left: -currentSlide * slideWidth }, 600).data('current', currentSlide);
}

function prevSlide() {
    var currentSlide = parseInt($('.slidewrapper').data('current'));
    currentSlide--;
    if (currentSlide < 0) {
        currentSlide = $('.slidewrapper').children().length - 1;
    }
    $('.slidewrapper').animate({ left: -currentSlide * slideWidth }, 600).data('current', currentSlide);
}