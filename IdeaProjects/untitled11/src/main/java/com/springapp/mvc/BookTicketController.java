package com.springapp.mvc;

import domain.TicketForm;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.util.Assert;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.SessionAttributes;
import org.springframework.web.bind.support.SessionStatus;

import java.util.HashSet;
import java.util.Set;

@Controller
@RequestMapping(value = "/booking")
@SessionAttributes(types = TicketForm.class)
public class BookTicketController {

    @RequestMapping(method = RequestMethod.GET)
    public String start(Model model) {
        // после выхода из start() форма будет скопирована в http session атрибуты благодаря @SessionAttributes(types = TicketForm.class)
        model.addAttribute(new TicketForm());
        return "booking/booking";
    }

    @RequestMapping(value = "/movie", method = RequestMethod.POST)
    public String selectMovie(TicketForm ticketForm) {

        Assert.notNull(ticketForm);
        Assert.notNull(ticketForm.getMovieId());

        return "booking/customer";
    }

    @RequestMapping(value = "/customer", method = RequestMethod.POST)
    public String enterCustomerData(TicketForm ticketForm) {

        Assert.notNull(ticketForm);
        // movieId не передавался с customer.jsp, но он был сохранен в сессии во время selectMovie()
        Assert.notNull(ticketForm.getMovieId());
        Assert.notNull(ticketForm.getLastName());

        return "booking/payment";
    }

    @RequestMapping(value = "/do", method = RequestMethod.GET)
    public String do1(){
        return "contacts/list";
    }


    @RequestMapping(value = "/payment", method = RequestMethod.POST)
    public String enterPaymentDetails(TicketForm ticketForm) {

        // movieId не передавался с customer.jsp, но он был сохранен в сессии во время selectMovie()
        Assert.notNull(ticketForm.getMovieId());
        // lastName не передавался с payment.jsp, но он был сохранен в сессии во время enterCustomerData()
        Assert.notNull(ticketForm.getLastName());
        Assert.notNull(ticketForm.getCreditCardNumber());

        return "redirect:/booking/confirmation";
    }

    @RequestMapping(value = "/confirmation", method = RequestMethod.GET)
    public String confirmation(SessionStatus status) {
        status.setComplete(); // очищаем Spring Session в целях безопасности личных данных
        return "booking/confirmation";
    }

    @RequestMapping(value = "/ajaxtest", method = RequestMethod.POST)
    @ResponseBody
    public Set<String> ajaxTest(String movieId) {
        Set<String> records = new HashSet<String>();
        records.add("Record #1" + movieId);
        records.add("Record #2");

        return records;
    }

}