<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ taglib uri="http://www.springframework.org/tags/form" prefix="form"%>
<html>
<head>
    <title>Booking Start Page</title>
    <link rel="stylesheet" href="../../styles/style.css"/>
    <script src="../../scripts/jquery-2.1.3.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-2.1.3.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui.min.css" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
</head>
<body>
<script>
    $(function(){
        $("#birthDay").datepicker({
            dateFormat:'yy-mm-dd',
            changeYear: true
        })
    })
</script>
<form:form action="/contacts/update" modelAttribute="contact">
    First Name : <form:input path="firstName" id="firstName" cssClass="main"/> <br/>
    <div>
        <form:errors cssStyle="color: red;" path="firstName"/>
    </div>
    Last Name : <form:input path="lastName"/> <br/>
    Birth day : <form:input  path="birthDay" placeholder="dd/MM/yyyy"/><br/>
    <div>
        <form:errors cssStyle="color: red;" path="birthDay"/>
    </div>
    Id : <form:input path="id"/> <br/>
    <input type="submit"/>
</form:form>
</body>
</html>