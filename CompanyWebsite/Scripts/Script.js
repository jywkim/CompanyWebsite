$(document).ready(function () {
    $('.portfolio-carousel').slick({
        infinite: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: true,
    });
});

$(document).ready(function () {
    $('.clients-carousel').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 3,
        arrows: true,
    });
});

function openNav() {
    document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

$(function () {
    $('.navbar-item').bind('click', function (event) {
        event.preventDefault();
        var $anchor = $(this);
        console.log($anchor.attr('href'))
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1000);
        event.preventDefault();
    });
});

$(function () {
    $(document).on('click', function (e) {
        if (e.target.id != 'menu-box' && e.target.id != 'menu-text' && e.target.id != 'menu-icon') {
            closeNav();
        }
    })
});

function moveUp(container, object, speed) {
    var speed = 1200 || speed;

    container.css("position", "relative");
    object.css("position", "absolute");
    object.css("top", container.height() + "px");
    object.css("opacity", "0");

    object.animate({
        top: 60,
        opacity: 1
    }, speed);
}

moveUp($("#jumbotron-home"), $("#home-paragraph"));

$('.counting').each(function () {
    var $this = $(this),
        countTo = $this.attr('data-count');

    $({ countNum: $this.text() }).animate({
        countNum: countTo
    },

        {

            duration: 3000,
            easing: 'linear',
            step: function () {
                $this.text(Math.floor(this.countNum));
            },
            complete: function () {
                $this.text(this.countNum);
            }

        });
});

jQuery(document).ready(function () {
    var offset = 220;
    var duration = 500;
    jQuery(window).scroll(function () {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.back-to-top').fadeIn(duration);
        } else {
            jQuery('.back-to-top').fadeOut(duration);
        }
    });

    jQuery('.back-to-top').click(function (event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    })
});

function initMap() {
    var rea = { lat: 43.688837, lng: -79.391874 };

    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 4, center: rea });

    var marker = new google.maps.Marker({ position: rea, map: map });
}