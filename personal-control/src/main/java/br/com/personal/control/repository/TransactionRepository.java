package br.com.personal.control.repository;

import org.springframework.data.repository.CrudRepository;

import br.com.personal.control.model.Transaction;

public interface TransactionRepository extends CrudRepository<Transaction, Long> {
	
}
