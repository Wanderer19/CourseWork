<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<html>
<head>
    <title>Booking Start Page</title>
</head>
<body>
<script src="../../scripts/jquery-2.1.3.js" type="text/javascript"></script>
<script src="../../scripts/jquery-2.1.3.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script>
    $(document).ready(function(){
        $("#test").click(function(){
            alert("yes")
            $.ajax({
                type:'POST',
                url: '/booking/ajaxtest',
                dataType:'json',
                data : {movieId: $("#movieId").val()},
                success: function(data){
                    alert(data);
                },
                error: function(ex){
                    alert("error" + ex)
                }
            })
        })
    })
</script>
<form:form action="/booking/movie" modelAttribute="ticketForm">
    Movie ID : <form:input path="movieId"/>
    <input type="submit"/>
</form:form>

<input type="button" id="test" value="Ok">
</body>
</html>