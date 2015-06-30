import javax.persistence.*;

@Entity
@Table(name= "course")
public class Course {
    @Id
    @Column(name = "id")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;

    @Column(name = "name")
    private String name;

    @ManyToOne(cascade = {CascadeType.REFRESH}, fetch = FetchType.LAZY)
    @JoinColumn(name = "person1_id")
    private Person1 person1;

    public Course(){

    }

    public Course(String name){
        this.name = name;
    }

    public void setPerson1(Person1 person1) {
        this.person1 = person1;
    }

    public Person1 getPerson1() {
        return person1;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }
}
