
$(function () {
     
    function mouseEnter() {
       $(this).find('img').attr('src', '/media/ecbfaudo/search-pink.png');
    };
    
    function mouseLeave() {
        $(this).find('img').attr('src', '/media/wfjn1joc/search-blue.png');
    };
    
    function hideShowMobileDesktopCategories() {
        if ($(window).width() <= 843) {
            $('#blogSearchMobile').show();
            $('.Category__List').hide();
        } else {
            $('#blogSearchMobile').hide();
            $('.Category__List').css("display", "flex");
        }
    }

    console.log("dsfsdfsdfdsfdsdf");


    $('#blogSearch a').hover(mouseEnter, mouseLeave);   

    $('#blogSearchMobile a').hover(mouseEnter, mouseLeave);

    hideShowMobileDesktopCategories();

    console.log("adff");
    
    //Utility Functions for Blog
    $(window).resize(function() {
        if(this.resizeTO) clearTimeout(this.resizeTO);
        this.resizeTO = setTimeout(function() {
            $(this).trigger('resizeEnd');
        }, 300);
    });
    
    $(window).bind('resizeEnd', function() {
        //do something, window hasn't changed size in 300ms
        hideShowMobileDesktopCategories();
    });

    $(".sm-close").on("click", function () {
        $('.s-media').addClass('sm-collapse');
        $('.sm-open').delay(300).css('left', '0');
    });

    $('.sm-open').click(function () {
        $('.sm-open').css('left', '-60px');
        $('.s-media').removeClass('sm-collapse');
    });
});


$(document).ready(function () {


    
    

    

});// END DOCUMENT.Ready

