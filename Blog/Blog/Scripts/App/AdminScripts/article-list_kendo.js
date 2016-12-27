$(document).ready(function () {
	$("#articleGrid").kendoGrid({
		dataSource: {
			transport: {
				read: {
					type: "GET",
					url: "/Admin/GetAllArticle",
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
			field: "Title",
			title: document.getElementById('Resource_Title').value,
			width: "140px"
		},
		{
			field: "Text",
			title: document.getElementById('Resource_Text').value,
			width: "450px"
		},
		{
			field: "CreationDate",
			title: document.getElementById('Resource_CreationDate').value,
			width: "130px"
		},
		{
			command: [{
				click: editArticle,
				text: document.getElementById('Resource_Edit').value
			},
			{
				click: deleteArticle,
				text: document.getElementById('Resource_Delete').value
			}],
			width: "130px"
		}
		]
	});

	function editArticle(e) {
		e.preventDefault();
		var article = this.dataItem($(e.currentTarget).closest("tr"));
		window.location.href = '/Admin/Edit?id=' + article.Id;
	}
	function deleteArticle(e) {
		e.preventDefault();
		var article = this.dataItem($(e.currentTarget).closest("tr"));
		window.location.href = '/Admin/Delete?id=' + article.Id;
	}
});