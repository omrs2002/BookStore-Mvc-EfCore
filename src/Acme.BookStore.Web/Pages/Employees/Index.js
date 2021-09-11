$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employees/EditModal');

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.employees.employee.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    //visible: abp.auth.isGranted('BookStore.Books.Edit'),
                                    visible: true,
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    //visible: abp.auth.isGranted('BookStore.Books.Delete'),
                                    visible: true,
                                    confirmMessage: function (data) {
                                        return l(
                                            'EmployeeDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    }

                                    ,
                                    action: function (data) {
                                        acme.bookStore.employees.employee
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                },
                                {
                                    text: l('SetManager'),
                                    visible: true,
                                    confirmMessage: function (data) {
                                        return l(
                                            'ConfirmSetManager',
                                            data.record.name
                                        );
                                    }

                                    ,
                                    action: function (data) {
                                        acme.bookStore.employees.employee.setEmployeeToManager(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyUpdated')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "employeeName"
                },
                {
                    title: l('Salary'),
                    data: "salary"
                },
                {
                    title: l('Age'),
                    data: "age"
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
