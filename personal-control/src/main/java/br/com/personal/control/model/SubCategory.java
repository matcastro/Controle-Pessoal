package br.com.personal.control.model;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity(name="TB_SUB_CATEGORIA")
public class SubCategory {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="ID_SUB_CATEGORIA", nullable=false)
	private Long id;
	
	@Column(name="NM_SUB_CATEGORIA", nullable=false)
	private String name;
	
	@Column(name="DS_SUB_CATEGORIA")
	private String description;
	
	@ManyToOne
	@JoinColumn(name="ID_CATEGORIA", referencedColumnName="ID_CATEGORIA")
	private Category category;

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

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Category getCategory() {
		return category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}

}
