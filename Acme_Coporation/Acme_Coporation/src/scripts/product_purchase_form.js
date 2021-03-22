var product_purchase_form = {
	data: {
		//Elements
		elements: {
			//jQuery
			//Body element
			jquery_body_element: $(document.body),
			jquery_head_element: $('head'),
			//Classes
			product_list: ('.product_list'),
			current_user_fullname: $('.currentUserFullName'),
			current_user_email: $('.currentUserEmail'),
			product_name: $('.productName'),
			product_serial_number: $('.productSerialNumber'),

			successful_post: $('#successfulPost'),
			

		}
	},
	init: function() {

		let _this = this;

		$(".product_submit").on('click', function (e) {

			e.preventDefault();

			let current_selected_product_name = $(this).parent(_this.data.elements.product_list).find(_this.data.elements.product_name).data('productname');
			let current_selected_product_serial_number = $(this).parent(_this.data.elements.product_list).find(_this.data.elements.product_serial_number).data('productserialnumber');

			var formData = new FormData();
			formData.append("fullname", _this.data.elements.current_user_fullname.data('currentuserfullname'));
			formData.append("emailaddress", _this.data.elements.current_user_email.data('currentuseremail'));
			formData.append("productname", current_selected_product_name);
			formData.append("productserialnumber", current_selected_product_serial_number);

			$.ajax({
				type: "POST",
				url: "/umbraco/api/ProductsPurchaseForm/ProductsPurchaseFormSubmit",
				dataType: "json",
				contentType: false, 
				processData: false, 
				data: formData,
				success: function (result, status, xhr) {
					alert(result);
					if (result.includes("Status = :")) {
						alert(result);
						window.location.replace("/products-list/?success=true");
						return;
					}
				},
				error: function (xhr, status, error) {
					alert(status);
				}
			});
		});

		let current_url = window.location.href;
		if (current_url.indexOf("success") > -1) {
			_this.data.elements.successful_post.css('display', 'block');
		}

		console.log('go go go');

	}
};