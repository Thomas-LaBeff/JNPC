'use strict';

$(function() {

    var width = 900;
    var animationSpeed = 1000;
    var pause = 12000;
    var currentSlide = 1;

    // cache DOM
    var $slider = $('#slider');
    var $slideContainer = $slider.find('.slides');
    var $slides = $slideContainer.find('.slide');


    var interval;

    function startSlider() { 
    setInterval(function () {
        interval = $slideContainer.animate({ 'margin-left': '-=' + width}, animationSpeed, function(){
            currentSlide++;
        if (currentSlide === $slides.length) {
            currentSlide = 1;
            $slideContainer.css('margin-left', 0);
            }
        });
    }, pause);
    }

    function stopSlider() {
        clearInterval(interval);
    }
    $slider.on('mouseenter', stopSlider).on('mouseleave', startSlider);

    startSlider();
});
