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

		}
	},
	init: function() {

		let _this = this;

		$("#submit").on('click', function () {
			var formData = new FormData();

			formData.append("firstname", _this.data.elements.input_first_name.val().trim());
			formData.append("lastname", _this.data.elements.input_last_name.val().trim());

			$.ajax({
				type: "POST",
				url: "/umbraco/api/CompetitionForm/competitionformsubmit",
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

		console.log('yo yo yo');

	}
};