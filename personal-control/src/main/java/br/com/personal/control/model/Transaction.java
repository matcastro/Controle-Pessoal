package br.com.personal.control.model;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;

@Entity(name = "TB_MOVIMENTACAO")
public class Transaction {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "ID_MOVIMENTACAO", nullable = false)
	private Long id;

	@Column(name = "DS_MOVIMENTACAO")
	private String description;

	@Column(name = "VL_MOVIMENTACAO", nullable = false)
	private BigDecimal value;

	@Column(name = "DT_MOVIMENTACAO", nullable = false)
	private Calendar date;

	@ManyToOne
	@JoinColumn(name = "ID_TIPO_PAGAMENTO", referencedColumnName = "ID_TIPO_PAGAMENTO", nullable = false)
	private PaymentType paymentType;

	@ManyToOne
	@JoinColumn(name = "ID_TIPO_MOVIMENTACAO", referencedColumnName = "ID_TIPO_MOVIMENTACAO", nullable = false)
	private TransactionType transactionType;

	@ManyToOne
	@JoinColumn(name = "ID_USUARIO", referencedColumnName = "ID_USUARIO")
	private User user;

	@ManyToOne
	@JoinColumn(name = "ID_CATEGORIA", referencedColumnName = "ID_CATEGORIA", nullable = false)
	private Category category;

	@JoinColumn(name = "ID_SUB_CATEGORIA", referencedColumnName = "ID_SUB_CATEGORIA", nullable = false)
	private SubCategory subCategory;

	@OneToMany(mappedBy = "transaction")
	private List<Instalment> instalments;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public BigDecimal getValue() {
		return value;
	}

	public void setValue(BigDecimal value) {
		this.value = value;
	}

	public Calendar getDate() {
		return date;
	}

	public void setDate(Calendar date) {
		this.date = date;
	}

	public PaymentType getPaymentType() {
		return paymentType;
	}

	public void setPaymentType(PaymentType paymentType) {
		this.paymentType = paymentType;
	}

	public TransactionType getTransactionType() {
		return transactionType;
	}

	public void setTransactionType(TransactionType transactionType) {
		this.transactionType = transactionType;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}

	public Category getCategory() {
		return category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}

	public SubCategory getSubCategory() {
		return subCategory;
	}

	public void setSubCategory(SubCategory subCategory) {
		this.subCategory = subCategory;
	}

	public List<Instalment> getInstalments() {
		return instalments;
	}

	public void setInstalments(List<Instalment> instalments) {
		this.instalments = instalments;
	}

}
