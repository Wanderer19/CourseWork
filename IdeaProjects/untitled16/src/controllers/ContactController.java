package controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.SessionAttributes;

@Controller
@RequestMapping("/contacts")
@SessionAttributes
public class ContactController {

    @RequestMapping(value = "/list", method = RequestMethod.GET)
    public String showContacts(Model model) {
        return "contacts/contact";
    }

    @RequestMapping(value = "/all", method = RequestMethod.POST)
    public @ResponseBody String[] getAll(String id){
        return new String[]{id + ")", id + "("};
    }
}
