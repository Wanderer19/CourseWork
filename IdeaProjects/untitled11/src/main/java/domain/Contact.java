package domain;

import org.hibernate.validator.constraints.NotEmpty;
import org.springframework.format.annotation.DateTimeFormat;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Past;
import java.util.Date;

@Table(name = "contact")
@Entity
public class Contact {
    @Id
    @Column(name = "id")
    public Integer id;

    @Column(name = "first_name")
    @NotEmpty(message = "enter your first name!")
    public String firstName;

    @Column(name = "last_name")
    public String lastName;

    @Column(name = "birthday")
    @DateTimeFormat(pattern="dd/MM/yyyy")
    @Past
    @NotNull(message = "enter your birthDay")
    public Date birthDay;

    public Contact(){}

    public Contact(int id, String firstName, String lastName){
        setId(id);
        setFirstName(firstName);
        setLastName(lastName);
    }

    public Integer getId() {
        return id;
    }

    public String getFirstName() {
        return firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public Date getBirthDay() {
        return birthDay;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public void setBirthDay(Date birthDay) {
        this.birthDay = birthDay;
    }
}
