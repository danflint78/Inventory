$(document).ready(function () {
    var currentPosition = 0;
    var slideWidth = 320;
    var slides = $('.slide');
    var numberOfSlides = slides.length;
    var slideInterval;
    var speed = 3500;

    slideInterval = setInterval(changePosition, speed);

    slides.wrapAll('<div id="slidesHolder"></div>')
    slides.css({ 'float': 'left' });
    $('#slidesHolder').css('width', slideWidth * numberOfSlides);

    function changePosition() {
        if (currentPosition == numberOfSlides - 1) {
            currentPosition = 0;
        }
        else {
            currentPosition++;
        }
        moveSlide();
    }

    function moveSlide() {
        $('#slidesHolder').animate({ 'marginLeft': slideWidth * (-currentPosition) });
    }
});