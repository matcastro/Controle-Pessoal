package br.com.personal.control.model;

import java.util.Calendar;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity(name="TB_USUARIO")
public class User {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ID_USUARIO", nullable=false)
	private Long id;
	
	@Column(name="NM_USUARIO", nullable=false)
	private String name;
	
	@Column(name="TX_LOGIN", nullable=false)
	private String username;
	
	@Column(name="TX_SENHA", nullable=false)
	private String password;
	
	@Column(name="TX_EMAIL", nullable=false)
	private String email;
	
	@Column(name="NUM_IDADE")
	private Integer age;
	
	@Column(name="NUM_CPF", nullable=false, unique=true)
	private String cpf;
	
	@Column(name="DT_CADASTRO", nullable=false)
	private Calendar registerDate;
	
	@Column(name="DT_ATUALIZACAO", nullable=false)
	private Calendar updateDate;
	
	@OneToMany(mappedBy="user")
	private List<Transaction> transactions;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public Integer getAge() {
		return age;
	}

	public void setAge(Integer age) {
		this.age = age;
	}

	public String getCpf() {
		return cpf;
	}

	public void setCpf(String cpf) {
		this.cpf = cpf;
	}

	public Calendar getRegisterDate() {
		return registerDate;
	}

	public void setRegisterDate(Calendar registerDate) {
		this.registerDate = registerDate;
	}

	public Calendar getUpdateDate() {
		return updateDate;
	}

	public void setUpdateDate(Calendar updateDate) {
		this.updateDate = updateDate;
	}

	public List<Transaction> getTransactions() {
		return transactions;
	}

	public void setTransactions(List<Transaction> transactions) {
		this.transactions = transactions;
	}
}
