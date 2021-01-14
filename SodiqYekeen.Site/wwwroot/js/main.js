/*global $, jQuery, alert*/
//$(document).ready(function () {
function onBlazorReady() {

    'use strict';

    window.isHomepage = () => {
        return $('.home').length;
    }


    // ========================================================================= //
    //  //NAVBAR SHOW - HIDE
    // ========================================================================= //


    $(window).scroll(function () {
        var scroll = $(window).scrollTop();

        if (scroll > 100) {

            $("#main-nav, #main-nav-subpage").slideDown(700);
            $("#main-nav-subpage").removeClass('subpage-nav');
        } else {
            //alert("hide");
            $("#main-nav").slideUp(700);
            $("#main-nav-subpage").hide();
            $("#main-nav-subpage").addClass('subpage-nav');
        }

    });

    // ========================================================================= //
    //  // RESPONSIVE MENU
    // ========================================================================= //

    $('.responsive').on('click', function (e) {
        $('.nav-menu').slideToggle();
    });

    $('.nav-menu').children('li').on('click', function (e) {
        const media = window.matchMedia("(min-width: 992px)");
        console.log(media);
        if (!media.matches) {
            $('.nav-menu').slideToggle();
        }
    });


    // ========================================================================= //
    //  Owl Carousel Services
    // ========================================================================= //


    $('.services-carousel').owlCarousel({
        autoplay: true,
        loop: true,
        margin: 20,
        dots: true,
        nav: false,
        responsiveClass: true,
        responsive: { 0: { items: 1 }, 768: { items: 2 }, 900: { items: 4 } }
    });


    // ========================================================================= //
    //  Porfolio isotope and filter
    // ========================================================================= //


    var portfolioIsotope = $('.portfolio-container').isotope({
        itemSelector: '.portfolio-thumbnail',
        layoutMode: 'fitRows'
    });

    $('#portfolio-flters li').on('click', function () {
        $("#portfolio-flters li").removeClass('filter-active');
        $(this).addClass('filter-active');

        portfolioIsotope.isotope({ filter: $(this).data('filter') });
    });


    // ========================================================================= //
    //  magnificPopup
    // ========================================================================= //

    var magnifPopup = function () {
        $('.popup-img').magnificPopup({
            type: 'image',
            removalDelay: 300,
            mainClass: 'mfp-with-zoom',
            gallery: {
                enabled: true
            },
            zoom: {
                enabled: true, // By default it's false, so don't forget to enable it

                duration: 300, // duration of the effect, in milliseconds
                easing: 'ease-in-out', // CSS transition easing function

                // The "opener" function should return the element from which popup will be zoomed in
                // and to which popup will be scaled down
                // By defailt it looks for an image tag:
                opener: function (openerElement) {
                    // openerElement is the element on which popup was initialized, in this case its <a> tag
                    // you don't need to add "opener" option if this code matches your needs, it's defailt one.
                    return openerElement.is('img') ? openerElement : openerElement.find('img');
                }
            }
        });
    };


    // Call the functions
    magnifPopup();

}
//});