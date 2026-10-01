using SDL3;

namespace CreateWindow;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        if (!SDL.Init(SDL.InitFlags.Video))
        {
            SDL.LogError(SDL.LogCategory.System, $"SDL could not initialize: {SDL.GetError()}");
            return;
        }

        if (!SDL.CreateWindowAndRenderer("SDL3 Create Window", 800, 600, 0, out var window, out var renderer))
        {
            SDL.LogError(SDL.LogCategory.System, $"Error creating window and renderer: {SDL.GetError()}");
            return;
        }

        SDL.SetRenderDrawColor(renderer, 100, 149, 237, 255);

        var loop = true;

        while (loop)
        {
            while (SDL.PollEvent(out var e))
            {
                if (e.Type == (uint)SDL.EventType.Quit)
                {
                    loop = false;
                }
            }

            SDL.RenderClear(renderer);
            SDL.RenderPresent(renderer);
        }

        SDL.DestroyRenderer(renderer);
        SDL.DestroyWindow(window);

        SDL.Quit();
    }
}