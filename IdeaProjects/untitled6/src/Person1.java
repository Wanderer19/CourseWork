import javax.persistence.*;

@Entity
@Table(name= "person1")
public class Person1 {
    @Id
    @Column(name= "id")
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name= "name", length=64)
    private String name;

    @Column(name = "age")
    private Integer age;

    @Column(name = "course", columnDefinition = "int default 1")
    private Integer course;

    @OneToMany(cascade = CascadeType.ALL, fetch = FetchType.LAZY, mappedBy="person1")
    @OrderColumn
    private Course[] courses;

    public Course[] getCourses() {
        return courses;
    }

    public void setCourses(Course[] courses) {
        this.courses = courses;
    }

    public Integer getCourse() {
        return course;
    }

    public void setCourse(Integer course) {
        this.course = course;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
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