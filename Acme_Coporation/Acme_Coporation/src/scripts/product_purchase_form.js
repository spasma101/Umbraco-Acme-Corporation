var product_purchase_form = {
	data: {
		//Elements
		elements: {
			//jQuery
			//Body element
			jquery_body_element: $(document.body),
			jquery_head_element: $('head'),
			//Classes
			current_user_fullname: $('.currentUserFullName'),
			current_user_email: $('.currentUserEmail'),
			product_serial_number: $('.productSerialNumber'),
			

		}
	},
	init: function() {

		let _this = this;

		$(".product_submit").on('click', function () {

			var formData = new FormData();
			console.log(_this.data.elements.current_user_fullname.data('currentuserfullname'));
			formData.append("fullname", _this.data.elements.current_user_fullname.data('currentuserfullname'));
			console.log(_this.data.elements.current_user_email.data('currentuseremail'));
			formData.append("emailaddress", _this.data.elements.current_user_email.data('currentuseremail'));
			console.log(_this.data.elements.product_serial_number.data('productserialnumber'));
			formData.append("productserialnumber", _this.data.elements.product_serial_number.data('productserialnumber'));

			$.ajax({
				type: "POST",
				url: "/umbraco/api/ProductsPurchaseForm/ProductsPurchaseFormSubmit",
				dataType: "json",
				contentType: false, 
				processData: false, 
				data: formData,
				success: function (result, status, xhr) {
					alert(result);
				},
				error: function (xhr, status, error) {
					alert(status);
				}
			});
		});

		console.log('go go go');

	}
};