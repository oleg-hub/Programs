$(document).ready(function () {
	$("#grid").kendoGrid({
		dataSource: {
			transport: {
				read: {
					type: "GET",
					url: "/Admin/GetAllAdmin",
					contentType: "application/json; charset=utf-8",
				},
			},
			serverSorting: false,
			pageSize: 20,
			serverFiltering: false,
			serverPaging: false
		},
		autoBind: true,
		scrollable: true,
		filterable: true,
		sortable: true,
		groupable: false,
		pageable: true,
		columnMenu: true,
		mobile: true,
		columns: [
		{
			field: "UserName", title: document.getElementById('Resource_UserName').value, width: "140px"
		},
		{
			field: "Email", title: document.getElementById('Resource_Email').value, width: "450px"
		},
		{
			command: [{ click: deleteArticle, text: document.getElementById('Resource_Delete').value }], width: "130px"
		}
		]
	});

	function deleteArticle(e) {
		e.preventDefault();
		var admin = this.dataItem($(e.currentTarget).closest("tr"));
		window.location.href = '/Admin/DeleteUser?id=' + admin.Id;
	}
});