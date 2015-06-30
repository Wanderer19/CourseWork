import javax.persistence.*;

@Entity
@Table(name= "person")
public class Person {
    @Id
    @Column(name= "id")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name= "name", length=64)
    private String name;

    public Person(){}

    public Person(String name){
        setName(name);
    }

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
