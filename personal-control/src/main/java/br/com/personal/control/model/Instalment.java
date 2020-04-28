package br.com.personal.control.model;

import java.math.BigDecimal;
import java.util.Calendar;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity(name="TB_PARCELA")
public class Instalment {
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ID_PARCELA", nullable=false)
	private Long id;
	
	@Column(name="NUM_PARCELA", nullable=false)
	private Integer numeroParcela;
	
	@Column(name="DT_PAGAMENTO", nullable=false)
	private Calendar dataPagamento;
	
	@Column(name="VL_PARCELA", nullable=false)
	private BigDecimal valor;
	
	@ManyToOne
	@JoinColumn(name="ID_MOVIMENTACAO", referencedColumnName="ID_MOVIMENTACAO")
	private Transaction transaction;

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Integer getNumeroParcela() {
		return numeroParcela;
	}

	public void setNumeroParcela(Integer numeroParcela) {
		this.numeroParcela = numeroParcela;
	}

	public Calendar getDataPagamento() {
		return dataPagamento;
	}

	public void setDataPagamento(Calendar dataPagamento) {
		this.dataPagamento = dataPagamento;
	}

	public BigDecimal getValor() {
		return valor;
	}

	public void setValor(BigDecimal valor) {
		this.valor = valor;
	}

	public Transaction getTransaction() {
		return transaction;
	}

	public void setTransaction(Transaction transaction) {
		this.transaction = transaction;
	}
}
