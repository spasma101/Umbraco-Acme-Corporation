var header_scroll = {
	init: function() {
		// When the user scrolls the page, execute myFunction
		window.onscroll = function() {myFunction()};

		// Get the header
		var header = document.getElementById("header");
		// Get the offset position of the navbar
		var sticky = header.offsetTop;

		// Add the sticky class to the header when you reach its scroll position. Remove "sticky" when you leave the scroll position
		function myFunction() {
			if (window.pageYOffset > sticky) {
				header.classList.add("sticky");
			} else {
				header.classList.remove("sticky");
			}
		}

	}
};

var mobile_nav = {
	data:{
		//Elements
		elements: {
			//jQuery
			main_nav_hamburger: $('#main_nav_hamburger'),
			Mobile_Nav_Child_Switch: $('._show_nav_children'),
			Mobile_Nav_Child: $('._nav_child'),
			back_button: $('._back_button'),


			desktop_nav_business_switch: $('#business_menu_open'),
			desktop_nav_personal_switch: $('#personal_menu_open'),
			desktop_nav_business_block: $('#desktop_nav_business'),
			desktop_nav_personal_block: $('#desktop_nav_personal'),
			body_html: $('body,html'),
		}
	},
	

	
	init: function() {

		//When hamburger clicked on mobile, slide in the mobile Nav 
		//and change the hamburger to active state
		mobile_nav.data.elements.main_nav_hamburger.on('click', function() {
			$(this).toggleClass('is-active');
			$('.mobile_nav').toggleClass('move-right');
			mobile_nav.data.elements.body_html.toggleClass('body-fixed');
		});

		//Slide in the business mobile navigation
		mobile_nav.data.elements.Mobile_Nav_Child_Switch.on('click', function() {
			// console.log($(this).next());
			$(this).next().toggleClass('move-right')
		});

		mobile_nav.data.elements.back_button.on('click', function() {
			console.log($(this).parent().parent());
			$(this).parent().parent().toggleClass('move-right');
		});


		//DESKTOP
		//mouseenter / over event to show nav blocks
		mobile_nav.data.elements.desktop_nav_business_switch.on('mouseenter', function() {
			mobile_nav.data.elements.desktop_nav_business_block.animate({height:"270px"},300).css('display', 'block');

			mobile_nav.data.elements.desktop_nav_personal_block.animate({height:"0px"},300).css('display', 'none');

			mobile_nav.data.elements.desktop_nav_personal_block.clearQueue().finish();

		});
		mobile_nav.data.elements.desktop_nav_personal_switch.on('mouseenter', function() {
			mobile_nav.data.elements.desktop_nav_personal_block.animate({height:"270px"},300).css('display', 'block');

			mobile_nav.data.elements.desktop_nav_business_block.animate({height:"0px"},300).css('display', 'none');

			mobile_nav.data.elements.desktop_nav_business_block.clearQueue().finish();

		});

		//Mouse leave events to hide navs
		mobile_nav.data.elements.desktop_nav_business_block.on('mouseleave', function() {
			mobile_nav.data.elements.desktop_nav_business_block.animate({height:"0px"},300).css('display', 'none');
		});
		mobile_nav.data.elements.desktop_nav_personal_block.on('mouseleave', function() {
			mobile_nav.data.elements.desktop_nav_personal_block.animate({height:"0px"},300).css('display', 'none');
		});

		


	}
};