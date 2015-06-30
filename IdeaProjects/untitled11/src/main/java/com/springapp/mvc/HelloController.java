package com.springapp.mvc;

import domain.Contact;
import domain.ContactsRepository;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.SessionAttributes;

import javax.validation.Valid;
import java.util.ArrayList;

@Controller
@RequestMapping(value = "/contacts")
@SessionAttributes(types = Contact.class)
public class HelloController{

	@RequestMapping(method = RequestMethod.GET)
	public String list(Model model)  {
		Contact[] contacts = new ContactsRepository().getAll();

		model.addAttribute("contacts", contacts);
		return "contacts/list";
	}

	@RequestMapping(method = RequestMethod.GET, value = "/{id}")
	public String show(@PathVariable("id") Integer id, Model model){
		Contact contact = new ContactsRepository().findById(id);
		model.addAttribute("contact", contact);

		return "contacts/show";
	}

	@RequestMapping(method = RequestMethod.GET, value = "/names/{start}")
	public String names(@PathVariable("start") String start, Model model){
		ArrayList<Contact> contacts = new ContactsRepository().findByStartName(start);
		model.addAttribute("contacts", contacts);

		return "contacts/list";
	}

	@RequestMapping(method = RequestMethod.GET, params = "form", value = "/{id}")
	public String updateForm(@PathVariable("id") Integer id, Model model){
		model.addAttribute("contact", new ContactsRepository().findById(id));
		return "contacts/update";
	}

	@RequestMapping(method = RequestMethod.POST, value = "/update")
	public String update(@Valid Contact contact, BindingResult result){

		if (result.hasErrors()){
			return "contacts/update";
		}
		return "contacts/list";
	}
}
