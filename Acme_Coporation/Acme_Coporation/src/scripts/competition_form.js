var competition_form = {
	data: {
		//Elements
		elements: {
			//jQuery
			//Body element
			jquery_body_element: $(document.body),
			jquery_head_element: $('head'),
			//IDsf
			input_first_name: $('#inputFirstName'),
			input_last_name: $('#inputLastName'),
			input_email_address: $('#inputEmailAddress'),
			input_product_serial_number: $('#inputProductSerialNumber'),

			successful_post: $('#successfulPost'),
			error_post_failed: $('#errorPostFailed'),
			too_many_submissions: $('#tooManySubmissions'),

		}
	},
	init: function() {

		let _this = this;

		$("#submit").on('click', function () {

			var formData = new FormData();

			formData.append("firstname", _this.data.elements.input_first_name.val().trim());
			formData.append("lastname", _this.data.elements.input_last_name.val().trim());
			formData.append("emailaddress", _this.data.elements.input_email_address.val().trim());
			formData.append("productserialnumber", _this.data.elements.input_product_serial_number.val().trim());

			$.ajax({
				type: "POST",
				url: "/umbraco/api/CompetitionForm/competitionformsubmit",
				dataType: "json",
				contentType: false, 
				processData: false, 
				data: formData,
				success: function (result, status, xhr) {
					console.log(result);
					if(result === "Status = : Done!: One Code added") {
						alert(result);
						window.location.replace("/amazing-competition-page/?success=true");
						return;
					} 
					if(result === "Status = : Done!: Second code added") {
						alert(result);
						window.location.replace("/amazing-competition-page/?success=true");
						return;
					}
					if(result === "Status = : Error: too many entries made") {
						alert(result);
						window.location.replace("/amazing-competition-page/?error=too-many-entries");
						return;
					}
					if(result === "Status = : Error: Form Creation Failed") {
						alert(result);
						window.location.replace("/amazing-competition-page/?error=form-submit-failed");
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
		if (current_url.indexOf("error=too-many-entries") > -1) {
			_this.data.elements.too_many_submissions.css('display', 'block');
		}
		if (current_url.indexOf("error=form-submit-failed") > -1) {
			_this.data.elements.error_post_failed.css('display', 'block');
		}

		console.log('yo yo yo');

	}
};