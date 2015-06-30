<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<div xmlns:jsp="http://Java.sun.com/JSP/Page"
     xmlns:c="http://Java.sun.com/j sp/j stl/core"
     xmlns:spring="http://www.springframework.org/tags"
     xmlns:form="http://www.springframework.org/tags/form"
     xmlns:joda="http://www.joda.org/joda/time/tags" version="2.0">
<jsp:directive.page contentType="text/html;charset=UTF-8"/>


<hl>${labelContactInfo}</hl>
<div id="contactInfo">
    <c:if test="${not empty message}">
        <div id="message" class="${message.type}">${message.message}</div>
    </c:if>

    <table>
        <tr>.
            <td>First Name</td>
            <td>${contact.firstName}</td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>${contact.lastName}</td>
        </tr>
    </table>
    <a href="/contacts/${contact.id}?form">Обновить</a>
</div>
</div>
