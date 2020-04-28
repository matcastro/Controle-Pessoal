package br.com.personal.control.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import br.com.personal.control.model.Transaction;
import br.com.personal.control.repository.TransactionRepository;

@Service
public class TransactionService {
	
	@Autowired
	TransactionRepository repository;
	
	public Iterable<Transaction> findAll() {
		return repository.findAll();
	}
}
