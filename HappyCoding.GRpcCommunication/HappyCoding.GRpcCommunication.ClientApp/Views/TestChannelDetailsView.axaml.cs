using System;
using Avalonia;
using Avalonia.Controls;

namespace HappyCoding.GRpcCommunication.ClientApp.Views;

public partial class TestChannelDetailsView : UserControl
{
    public static readonly StyledProperty<TestChannelItemViewModel?> CurrentItemProperty =
        AvaloniaProperty.Register<TestChannelDetailsView, TestChannelItemViewModel?>(
            nameof(CurrentItem), null);

    public TestChannelItemViewModel? CurrentItem
    {
        get => this.GetValue(CurrentItemProperty);
        set
        {
            this.SetValue(CurrentItemProperty, value);
            OnCurrentItemChanged(this, false);
        }
    }

    public TestChannelDetailsView()
    {
        this.InitializeComponent();
    }

    private static void OnCurrentItemChanged(AvaloniaObject sender, bool beforeChanging)
    {
        if (beforeChanging) { return; }
        if (!(sender is TestChannelDetailsView view)) { return; }

        if (view.DataContext is TestChannelDetailsViewModel viewModel)
        {
            viewModel.CurrentItem = view.CurrentItem;
        }
    }
}
