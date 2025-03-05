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
class PostRelayAutoConfigExample
{
    fun postRelayAutoConfig()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val policy1 = Statement(
            effect = Statement.Effect.allow,
            resources = listOf (
                "proj/*:env/*",
            ),
            actions = listOf (
                "*",
            ),
        )

        val policy = arrayListOf<Statement>(
            policy1,
        )

        val relayAutoConfigPost = RelayAutoConfigPost(
            name = "Sample Relay Proxy config for all proj and env",
            policy = policy,
        )

        try
        {
            val response = RelayProxyConfigurationsApi().postRelayAutoConfig(
                relayAutoConfigPost = relayAutoConfigPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling RelayProxyConfigurationsApi#postRelayAutoConfig")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling RelayProxyConfigurationsApi#postRelayAutoConfig")
            e.printStackTrace()
        }
    }
}
