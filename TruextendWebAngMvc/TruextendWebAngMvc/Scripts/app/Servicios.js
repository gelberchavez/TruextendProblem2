var Servicios = angular.module('Servicios', []);
Servicios.factory('Servicios', [
    function () {
        return{
            GetStudents: function ( ){
                var result=null;
                $.ajax({
                    type: "GET",
                    url:"Students/GetStudents",
                    contentType: "application/json;charset=utf-8",
                    data: "{}",
                    async: false,
                    dataType: "json",
                    success: function (data){
                        result=data;
                    },
                    error: function (errordata){
                        alert(errordata.responseText);
                    }
                });
               return result;
            },
        }
    }
]);
