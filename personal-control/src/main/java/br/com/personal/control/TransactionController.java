package br.com.personal.control;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import br.com.personal.control.model.Transaction;
import br.com.personal.control.service.TransactionService;

@Controller
public class TransactionController {
	@Autowired
	private TransactionService service;
	
	@RequestMapping("/")
	public Iterable<Transaction> All() {
		return service.findAll();
	}
}
