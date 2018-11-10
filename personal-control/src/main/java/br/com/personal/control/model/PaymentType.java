package br.com.personal.control.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;

@Entity(name = "TB_TIPO_PAGAMENTO")
public class PaymentType {
	@Id
	@Column(name = "ID_TIPO_PAGAMENTO", nullable = false)
	private Long id;
	@NotEmpty
	@Column(name = "NM_TIPO_PAGAMENTO", nullable = false)
	private String name;

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
}
