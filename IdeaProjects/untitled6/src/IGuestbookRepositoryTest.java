import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import static org.hamcrest.core.Is.is;
import static org.mockito.Mockito.*;

public class IGuestbookRepositoryTest extends Assert {
    private static IGuestbookRepository spy = mock(IGuestbookRepository.class);
    private static Guestbook book;

    @Before
    public void setUp(){
        when(spy.getUserByLogin("login")).thenReturn(null);
        when(spy.getUserByLogin("wanderer")).thenReturn(new User("masha", "wanderer", "5"));
        when(spy.getUserByLogin("user")).thenReturn(new User("volkanin", "user", "qwer"));

        when(spy.containsLogin("login")).thenReturn(false);
        when(spy.containsLogin("wanderer")).thenReturn(true);
        when(spy.containsLogin("user")).thenReturn(true);

        book = new Guestbook(spy);
    }

    @Test
    public void getUserByLoginForNonexistentUserReturnsNull(){
        assertThat(book.registerUser("wanderer", "", ""), is(false));
        verify(spy, times(1)).containsLogin("wanderer");
        verify(spy, times(0)).addOrUpdateUser(new User("", "wanderer", ""));

        assertThat(book.registerUser("login", "", ""), is(true));
        verify(spy, times(1)).containsLogin("login");
        verify(spy, times(1)).addOrUpdateUser(new User("", "login", ""));

        assertThat(book.registerUser("user", "", ""), is(false));
        verify(spy, times(1)).containsLogin("user");
        verify(spy, times(0)).addOrUpdateUser(new User("", "user", ""));
    }
}