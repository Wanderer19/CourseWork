import javax.persistence.*;
import java.util.ArrayList;

@Entity
@Table(name = "user")
public class User {

    @Id
    @Column(name = "login", length = 50)
    private String login;

    @Column(name = "password")
    private String password;

    @Column(name = "name")
    private String name;

    @OrderColumn
    @OneToMany(cascade = CascadeType.ALL, fetch = FetchType.LAZY, mappedBy="user")
    private ArrayList<Message> messages;

    public User(){
        this.messages = new ArrayList<Message>();
    }

    public User(String name, String login, String password, Message ... messages){
        this.name = name;
        this.login = login;
        this.password = password;

        this.messages = new ArrayList<Message>(messages.length);
        for (Message m : messages){
            this.messages.add(m);
        }
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public ArrayList<Message> getMessages() {
        return messages;
    }

    public void setMessages(ArrayList<Message> messages) {
        this.messages = messages;
    }

    public void addMessage(Message message){
        messages.add(message);
    }

    @Override
    public boolean equals(Object obj) {
        User other = (User) obj;
        return other.login == login;
    }

    @Override
    public int hashCode() {
        return login.hashCode();
    }
}
