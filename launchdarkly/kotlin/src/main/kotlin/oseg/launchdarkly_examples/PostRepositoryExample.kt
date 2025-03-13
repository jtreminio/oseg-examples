package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PostRepositoryExample
{
    fun postRepository()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val repositoryPost = RepositoryPost(
            name = "LaunchDarkly-Docs",
            sourceLink = "https://github.com/launchdarkly/LaunchDarkly-Docs",
            commitUrlTemplate = "https://github.com/launchdarkly/LaunchDarkly-Docs/commit/\${sha}",
            hunkUrlTemplate = "https://github.com/launchdarkly/LaunchDarkly-Docs/blob/\${sha}/\${filePath}#L\${lineNumber}",
            type = RepositoryPost.Type.github,
            defaultBranch = "main",
        )

        try
        {
            val response = CodeReferencesApi().postRepository(
                repositoryPost = repositoryPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CodeReferencesApi#postRepository")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CodeReferencesApi#postRepository")
            e.printStackTrace()
        }
    }
}
