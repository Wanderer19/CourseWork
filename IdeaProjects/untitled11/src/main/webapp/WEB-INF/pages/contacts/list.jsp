<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<div xmlns:jsp="http://Java.sun.com/JSP/Page"
xmlns:c="http://Java.sun.com/jsp/jstl/core"
xmlns:joda="http://www.joda.org/joda/time/tags"
version="2.0">

    <jsp:directive.page contentType="text/html;charset=UTF-8"/>
    <spring:url value = "/contacts/" var="showContactUrl"/>

    <ul>
        <li>
            c#
        </li>
        <li>
            Java
        </li>
        <li>
            Perl
        </li>
        <li>
            c++
        </li>
        <li>
            Python
        </li>
        <c:if test="${not empty contacts}">
            <ol>
                <c:forEach items="${contacts}" var="contact">
                    <li>
                        <a href="/contacts/${contact.id}">${contact.firstName}</a>
                    </li>
                </c:forEach>
            </ol>

        </c:if>
    </ul>

</div>

