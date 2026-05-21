using EventAccountingSystemAPI.Models;

namespace EventAccountingSystemUI;

public partial class MainForm : Form
{
    private ApiClient _apiClient;
    private List<Event> _events = new List<Event>();

    public MainForm()
    {
        InitializeComponent();
        _apiClient = new ApiClient("https://localhost:7263/");
        this.Load += MainForm_Load;
        dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        btnAdd.Click += btnAdd_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnRefresh.Click += btnRefresh_Click;
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        await LoadEvents();
    }

    private async Task LoadEvents()
    {
        try
        {
            _events = await _apiClient.GetEventsAsync();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _events;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка загрузки: {ex.Message}");
        }
    }

    private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0) return;

        var selectedEvent = _events[dataGridView1.SelectedRows[0].Index];

        txtTitle.Text = selectedEvent.Title;
        txtLocation.Text = selectedEvent.Location;
        txtDescription.Text = selectedEvent.Description;
        dtpEventDate.Value = selectedEvent.EventDate;
        cmbType.SelectedItem = selectedEvent.Type;
        cmbStatus.SelectedItem = selectedEvent.Status.ToString();
    }

    private void ClearFields()
    {
        txtTitle.Clear();
        txtLocation.Clear();
        txtDescription.Clear();
        dtpEventDate.Value = DateTime.Now.AddDays(7);
        cmbType.SelectedIndex = 0;
        cmbStatus.SelectedIndex = 0;
    }

    private async void btnAdd_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTitle.Text))
        {
            MessageBox.Show("Введите название мероприятия");
            return;
        }

        string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Planned";
        EventStatus status = selectedStatus switch
        {
            "InProgress" => EventStatus.InProgress,
            "Completed" => EventStatus.Completed,
            "Canceled" => EventStatus.Canceled,
            _ => EventStatus.Planned
        };

        var newEvent = new Event
        {
            Title = txtTitle.Text,
            Description = txtDescription.Text,
            Location = txtLocation.Text,
            EventDate = dtpEventDate.Value,
            Type = cmbType.Text
        };
        newEvent.ChangeStatus(status);

        var response = await _apiClient.CreateEventAsync(newEvent);
        if (response.IsSuccessStatusCode)
        {
            await LoadEvents();
            ClearFields();
        }
        else
        {
            MessageBox.Show("Ошибка при добавлении");
        }
    }

    private async void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите мероприятие для изменения");
            return;
        }

        var selectedEvent = _events[dataGridView1.SelectedRows[0].Index];

        string selectedStatus = cmbStatus.SelectedItem?.ToString() ?? "Planned";
        EventStatus status = selectedStatus switch
        {
            "InProgress" => EventStatus.InProgress,
            "Completed" => EventStatus.Completed,
            "Canceled" => EventStatus.Canceled,
            _ => EventStatus.Planned
        };

        var updatedEvent = new Event
        {
            Id = selectedEvent.Id,
            Title = txtTitle.Text,
            Description = txtDescription.Text,
            Location = txtLocation.Text,
            EventDate = dtpEventDate.Value,
            Type = cmbType.Text
        };
        updatedEvent.ChangeStatus(status);

        var response = await _apiClient.UpdateEventAsync(selectedEvent.Id, updatedEvent);
        if (response.IsSuccessStatusCode)
        {
            await LoadEvents();
            ClearFields();
            MessageBox.Show("Мероприятие обновлено");
        }
        else
        {
            MessageBox.Show("Ошибка при изменении");
        }
    }

    private async void btnDelete_Click(object? sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("Выберите мероприятие для удаления");
            return;
        }

        var selectedEvent = _events[dataGridView1.SelectedRows[0].Index];

        var confirm = MessageBox.Show($"Удалить \"{selectedEvent.Title}\"?", "Подтверждение", MessageBoxButtons.YesNo);
        if (confirm == DialogResult.Yes)
        {
            var response = await _apiClient.DeleteEventAsync(selectedEvent.Id);
            if (response.IsSuccessStatusCode)
            {
                await LoadEvents();
                ClearFields();
            }
        }
    }

    private async void btnRefresh_Click(object? sender, EventArgs e)
    {
        await LoadEvents();
        ClearFields();
    }

    private void btnDelete_Click_1(object sender, EventArgs e)
    {

    }

    private void txtTitle_TextChanged(object sender, EventArgs e)
    {

    }

    private void btnAdd_Click_1(object sender, EventArgs e)
    {

    }
}